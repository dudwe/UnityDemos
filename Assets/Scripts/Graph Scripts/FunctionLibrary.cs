using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
public static class FunctionLibrary 
{
    static Function[] functions = {Fx,Fx2,Fx3,CosWave,Wave,MultiWave,MultiWaveDelayed,Ripple};

    public delegate float Function(float x, float t);



    public static Function GetFunction(int index){
        return functions[index];
    }

    public static float Fx(float x,float t){
        return x;
    }
    public static float Fx2(float x,float t){
        return x*x;
    }
    public static float Fx3(float x,float t){
        return x*x*x;
    }

    public static float CosWave(float x, float t){
        return  Cos(PI * (x + t));
    }
    public static float Wave(float x, float t){
        return  Sin(PI * (x + t));
    }

    public static float MultiWave(float x,float t){
        //f(x,t) = sin (pi(x+t)) + sin(2pi(x+t))/2 sinx plus sing half freq
        float y = Wave(x,t);
        y += Sin(2*PI * (x+t)) * 0.5f;
        //reduce range to -1 - > 1
        y = y * (2f/3f);
        return y;

    }

    public static float MultiWaveDelayed(float x,float t){
        //f(x,t) = sin (pi(x+t)) + sin(2pi(x+t))/2 sinx plus sing half freq
        float y = Wave(x,0.5f*t);
        y += Sin(2*PI * (x+t)) * 0.5f;
        //reduce range to -1 - > 1
        y = y * (2f/3f);
        return y;
    }

    //Rippl eis based on a sine wave moving away from the origin
    public static float Ripple(float x, float t){
        float d = Abs(x);
        //y = sin(4 pi d - t)
        float y = Sin(4 * PI * d - t);
        //Scale the result
        y = y / (1f + 10f * d);
        return y;
    }




}
