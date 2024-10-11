using System;
using UnityEngine;

public class SimulationController : MonoBehaviour
{

    Body[] bodies;
    private static SimulationController instance;

    void Awake()
    {

        bodies = FindObjectsByType<Body>(FindObjectsSortMode.InstanceID);
        Debug.Log("Found : " + bodies.Length + " bodies");
    }

    void FixedUpdate()
    {
        foreach (Body t in bodies)
        {
            Vector3 acceleration = CalculateAcceleration(t);
            t.UpdateVelocity(acceleration, Time.deltaTime);
        }

    }

    private static Vector3 CalculateAcceleration(Body mainBody)
    {
        Vector3 acceleration = Vector3.zero;
        foreach (var body in Instance.bodies)
        {
            if (body.name != mainBody.name)
            {
                acceleration += -Universe.GravitationalConstant * body.mass * mainBody.mass *
                          (mainBody.transform.localPosition - body.transform.localPosition) /
                          MathF.Pow(MathF.Sqrt(
                                  MathF.Pow(mainBody.transform.localPosition[0] - body.transform.localPosition[0],
                                      2.0f) +
                                  MathF.Pow(mainBody.transform.localPosition[1] - body.transform.localPosition[1],
                                      2.0f) +
                                  MathF.Pow(mainBody.transform.localPosition[2] - body.transform.localPosition[2],
                                      2.0f)),
                              3.0f);
            }
        }
        return acceleration;
    }

    static SimulationController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectsByType<SimulationController>(FindObjectsSortMode.InstanceID)[0];
            }

            return instance;
        }
    }
}
