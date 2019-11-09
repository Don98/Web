using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHalo : MonoBehaviour {
	//各个粒子的属性
    private ParticleSystem particleSys;   
    private ParticleSystem.Particle[] particleArr;  
    private CirclePosition[] circle;
    public int count = 10000;      
    public float size = 0.03f;     
    public float minRadius = 5.0f;  
    public float maxRadius = 12.0f; 
    public bool clockwise = true;   
    public float speed = 2f;       
    public float maxRadiusChange = 0.02f; 
    private NormalDistribution normalGenerator = new NormalDistribution(); 
    public Color startColor = Color.blue;
    // Use this for initialization
    void Start()
    {   
        particleArr = new ParticleSystem.Particle[count];
        circle = new CirclePosition[count];

        // 初始化粒子系统  
        particleSys = this.GetComponent<ParticleSystem>();
        var main = particleSys.main;
        main.startSpeed = 0;              
        main.startSize = size;       
        main.loop = false;
        main.maxParticles = count;    
        particleSys.Emit(count);           
        particleSys.GetParticles(particleArr);

        RandomlyPos();  
    }

    // Update is called once per frame
    private int tier = 12; 
    void Update()
    {
        for (int i = 0; i < count; i++)
        {
            if (clockwise)  
                circle[i].angle -= (i % tier + 1) * (speed / circle[i].radius / tier);
            else       
                circle[i].angle += (i % tier + 1) * (speed / circle[i].radius / tier);

            circle[i].angle = (360.0f + circle[i].angle) % 360.0f;
            float theta = circle[i].angle / 180 * Mathf.PI;
            particleArr[i].position = new Vector3(circle[i].radius * Mathf.Cos(theta), 0f, circle[i].radius * Mathf.Sin(theta));
            particleArr[i].startColor = startColor;
            circle[i].time += Time.deltaTime;
            circle[i].radius += Mathf.PingPong(circle[i].time / minRadius / maxRadius, maxRadiusChange) - maxRadiusChange / 2.0f;
        }

        particleSys.SetParticles(particleArr, particleArr.Length);
    }

    void RandomlyPos()
    {
        for (int i = 0; i < count; ++i)
        {   
            float midRadius = (maxRadius + minRadius) / 2;
            float radius = (float)normalGenerator.NextGaussian(midRadius, 0.7);//使用高斯分布

            float angle = Random.Range(0.0f, 360.0f);
            float theta = angle / 180 * Mathf.PI;
            float time = Random.Range(0.0f, 360.0f);  
            float radiusChange = Random.Range(0.0f, maxRadiusChange);  
            circle[i] = new CirclePosition(radius, angle, time);
            particleArr[i].position = new Vector3(circle[i].radius * Mathf.Cos(theta), 0f, circle[i].radius * Mathf.Sin(theta));
        }

        particleSys.SetParticles(particleArr, particleArr.Length);
    }
}
