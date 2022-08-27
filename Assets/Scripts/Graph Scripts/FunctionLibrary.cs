using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
public static class FunctionLibrary 
{
    static Function[] functions = {Fx,Fx2,Fx3,CosWave,Wave,MultiWave,MultiWaveDelayed,Ripple,Cirlce,Cylinder,CylinderCollapse,Sphere,AnimatedSphere,BondedSphereHorizontal,BondedSphereVertical,BondedSphereTwisted,Torus,TwistingTorus,CoolShape};
    public enum FunctionName {Fx,Fx2,Fx3,CosWave,Wave,MultiWave,MultiWaveDelayed,Ripple,Cirlce,Cylinder,CylinderCollapse,Sphere,AnimatedSphere,BondedSphereHorizontal,BondedSphereVertical,BondedSphereTwisted,Torus,TwistingTorus,CoolShape}

    public delegate Vector3 Function(float u,float v, float t);



    public static Function GetFunction(FunctionName name){
        return functions[(int)name];
    }

    public static Vector3 Fx(float u,float v,float t){
        Vector3 p;
        p.x=u;
        p.y = u ;
        p.z = v;
        return p;
    }
    public static Vector3 Fx2(float u,float v,float t){
        Vector3 p;
        p.x=u;
        p.y = u  * u;
        p.z = v;
        return p;
    }
    public static Vector3 Fx3(float u,float v,float t){
        Vector3 p;
        p.x=u;
        p.y = u * u * u;
        p.z = v;
        return p;
    }

    public static Vector3 CosWave(float u,float v, float t){
        Vector3 p;
        p.x = u;
        p.y =  Cos(PI * (u +v + t));
        p.z = v;
        return  p;
    }
    public static Vector3 Wave(float u,float v, float t){
        Vector3 p;
        p.x = u;
        p.y =  Sin(PI * (u +v + t));
        p.z = v;
        return  p;
    }

    public static Vector3 MultiWave(float u,float v,float t){
        Vector3 p;
        p.x = u;
        p.z = v;
        //f(x,t) = sin (pi(x+t)) + sin(2pi(x+t))/2 sinx plus sing half freq
        float y = Sin(PI * (u +v + t));
        y += Sin(2*PI * (v+t)) * 0.5f;
        //reduce range to -1 - > 1
        y = y * (2f/3f);
        p.y =y;
        return p;

    }

    public static Vector3 MultiWaveDelayed(float u,float v,float t){
        //f(x,t) = sin (pi(x+t)) + sin(2pi(x+t))/2 sinx plus sing half freq
        Vector3 p;
        p.x=u;
        p.z=v;
        p.y =   Sin(PI * (u +v + t));

        p.y += Sin(2*PI * (u+t)) * 0.5f;
        //reduce range to -1 - > 1
        p.y += Sign(PI * (u+v + 0.25f *t));
        p.y = p.y * (1f/2.5f);
        return p;
    }

    //Rippl eis based on a sine wave moving away from the origin
    public static Vector3 Ripple(float u,float v, float t){
        Vector3 p;
        p.x=u;
        p.z=v;
        float d = Sqrt(u*u + v * v);
        //y = sin(4 pi d - t)
        p.y = Sin(4 * PI * d - t);
        //Scale the result
        p.y = p.y / (1f + 10f * d);
        return p;
    }

    public static Vector3 Cirlce(float u, float v, float t){
        //[sin(pi u),0, cos(pi u)]

        Vector3 p;
        p.x = Sin(PI * u);
        p.y = 0f;
        p.z = Cos(PI * u);
        return p;        
    }
    public static Vector3 Cylinder(float u, float v, float t){
        //[sin(pi u),v, cos(pi u)]

        Vector3 p;
        p.x = Sin(PI * u);
        p.y = v;
        p.z = Cos(PI * u);
        return p;        
    }

    public static Vector3 CylinderCollapse(float u, float v, float t){
        // r is the scale factor r = cos(1/2 Pi v)
        //[r *sin(pi u),v,r* cos(pi u)]

        Vector3 p;
        float r = Cos(0.5f * PI * v);
        p.x = r * Sin(PI * u);
        p.y = v;
        p.z = r * Cos(PI * u);
        return p;        
    }

    public static Vector3 Sphere(float u, float v, float t){
        // r is the scale factor r = cos(1/2 Pi v)
        //[r *sin(pi u),sing(1/2 pi v),r* cos(pi u)]

        Vector3 p;
        float r = Cos(0.5f * PI * v);
        p.x = r * Sin(PI * u);
        p.y = Sin(0.5f * PI * v);
        p.z = r * Cos(PI * u);
        return p;        
    }    

    public static Vector3 AnimatedSphere(float u, float v, float t){
        // r is the radius
        // s - r cos (0.5pi v)
        // [s sin(pi u), r sing(0.5pi v),s cos(pi u)]

    
        Vector3 p;
        // Let r be 1 + sin(pi t) / 2
        float r = ((1 + Sin(PI * t))/2);
        float s = r * Cos((PI/2) * v);

        p.x = s * Sin(PI * u);
        p.y = r * Sin(0.5f * PI * v);
        p.z = s * Cos(PI * u);
        return p;        
    }        

    public static Vector3 BondedSphereHorizontal(float u, float v, float t){
        // r is the radius
        // s - r cos (0.5pi v)
        // [s sin(pi u), r sing(0.5pi v),s cos(pi u)]

    
        Vector3 p;
        // Let r be (9 + sing(8 pi v)) / 10
        float r = (9 + Sin(8 * PI * v))/10;
        float s = r * Cos((PI/2) * v);

        p.x = s * Sin(PI * u);
        p.y = r * Sin(0.5f * PI * v);
        p.z = s * Cos(PI * u);
        return p;        
    }   
    public static Vector3 BondedSphereVertical(float u, float v, float t){
        // r is the radius
        // s - r cos (0.5pi v)
        // [s sin(pi u), r sing(0.5pi v),s cos(pi u)]

    
        Vector3 p;
        // Let r be (9 + sing(8 pi v)) / 10
        float r = (9 + Sin(8 * PI * u))/10;
        float s = r * Cos((PI/2) * v);

        p.x = s * Sin(PI * u);
        p.y = r * Sin(0.5f * PI * v);
        p.z = s * Cos(PI * u);
        return p;        
    }   
    public static Vector3 BondedSphereTwisted(float u, float v, float t){
        // r is the radius
        // s - r cos (0.5pi v)
        // [s sin(pi u), r sing(0.5pi v),s cos(pi u)]
        Vector3 p;
        // Let r be 1 + sin(pi t) / 2
        float r = (9 + Sin(PI * (6 * u + 4 * v + t)))/10;
        float s = r * Cos((PI/2) * v);

        p.x = s * Sin(PI * u);
        p.y = r * Sin(0.5f * PI * v);
        p.z = s * Cos(PI * u);
        return p;        
    }         

    public static Vector3 Torus(float u, float v, float t){
        Vector3 p;
        // Torus is made by separting the half circles 
        // s  = 1/2 r cos (0.5pi v )
        float r1 = 0.75f;
        float r2 = 0.25f;
        float s = r1 + r2 * Cos( PI * v);

        p.x = s * Sin(PI * u);
        p.y = r2 * Sin( PI * v);
        p.z = s * Cos(PI * u);
        return p;        
    }      

    public static Vector3 TwistingTorus(float u, float v, float t){
        Vector3 p;
        // To twist we make r1 and r2 vector and time dependant 
        float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
        float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t));
        float s = r1 + r2 * Cos( PI * v);

        p.x = s * Sin(PI * u);
        p.y = r2 * Sin( PI * v);
        p.z = s * Cos(PI * u);
        return p;        
    }              


    public static Vector3 CoolShape(float u, float v, float t){
        Vector3 p;
        float r =  0.5f * (9 + Sin(PI * (6 * u + 4 * v + t)))/10;
        float s = r  * Cos( PI * v);
        p.x = s * Sin(PI * u  );
        p.y = v;
        p.z = s * Cos(PI * v);
        return p;      
    }     
}
