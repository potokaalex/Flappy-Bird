using UnityEngine;
using Random = Unity.Mathematics.Random;
using System.Collections.Generic;
using System;

public class Pipes : MonoBehaviour
{
    public float initialTimeSec;

    public float lowerPipePoint;
    public float hiestPipePoint;

    public GameObject pipePrefab;

    public const float X_GAP = 49f / 25f;
    public const float Y_GAP = 45f / 25f;
    public const int SKULL_WIDTH = 24;
    public const int SKULL_HEIGHT = 11;

    public const float SCROLL_SPEED = -59f / 25f;

    private List<(GameObject, GameObject)> pipes;
    private Random r;

    private void Start()
    {
        r = new Random((uint)DateTime.Now.Ticks);
        pipes = new();

        for (var i = 0; i < 100; i++)
            Create((X_GAP + 26f / 25f) * i);
    }

    private float t;
    private void FixedUpdate()
    {
        t += Time.fixedDeltaTime;

        if (t <= initialTimeSec)
            return;

        foreach (var pipe in pipes)
        {
            pipe.Item1.transform.position += new Vector3(SCROLL_SPEED, 0, 0) * Time.deltaTime;
            pipe.Item2.transform.position += new Vector3(SCROLL_SPEED, 0, 0) * Time.deltaTime;
        }
    }

    public void Create(float newX)
    {
        //hiestPipePoint - lowerPipePoint <- максимальное смещение.

        var pos = new Vector3(newX + (- SCROLL_SPEED * initialTimeSec), lowerPipePoint +r.NextFloat(hiestPipePoint - lowerPipePoint), 0);

        var obg1 = Instantiate(pipePrefab, pos, Quaternion.identity);

        var rot = new Quaternion()
        {
            eulerAngles = new Vector3(0, 0, 180)
        };

        pos.y += Y_GAP;

        var obg2 = Instantiate(pipePrefab, pos, rot);

        pipes.Add((obg1, obg2));
    }
}

/*
 SCROLL_SPEED = -59;
 
public class Pipe extends Scrollable {

    private Random r;

    private Rectangle skullUp, skullDown, barUp, barDown;

    public static final int VERTICAL_GAP = 45;
    public static final int SKULL_WIDTH = 24;
    public static final int SKULL_HEIGHT = 11;
    private float groundY;

    private boolean isScored = false;

    // When Pipe's constructor is invoked, invoke the super (Scrollable)
    // constructor
    public Pipe(float x, float y, int width, int height, float scrollSpeed,
            float groundY) {
        super(x, y, width, height, scrollSpeed);
        // Initialize a Random object for Random number generation
        r = new Random();
        skullUp = new Rectangle();
        skullDown = new Rectangle();
        barUp = new Rectangle();
        barDown = new Rectangle();

        this.groundY = groundY;
    }

    @Override
    public void update(float delta) {
        // Call the update method in the superclass (Scrollable)
        super.update(delta);

        // The set() method allows you to set the top left corner's x, y
        // coordinates,
        // along with the width and height of the rectangle

        barUp.set(position.x, position.y, width, height);
        barDown.set(position.x, position.y + height + VERTICAL_GAP, width,
                groundY - (position.y + height + VERTICAL_GAP));

        // Our skull width is 24. The bar is only 22 pixels wide. So the skull
        // must be shifted by 1 pixel to the left (so that the skull is centered
        // with respect to its bar).

        // This shift is equivalent to: (SKULL_WIDTH - width) / 2
        skullUp.set(position.x - (SKULL_WIDTH - width) / 2, position.y + height
                - SKULL_HEIGHT, SKULL_WIDTH, SKULL_HEIGHT);
        skullDown.set(position.x - (SKULL_WIDTH - width) / 2, barDown.y,
                SKULL_WIDTH, SKULL_HEIGHT);

    }

    @Override
    public void reset(float newX) {
        // Call the reset method in the superclass (Scrollable)
        super.reset(newX);
        // Change the height to a random number
        height = r.nextInt(90) + 15;
        isScored = false;
    }

    public Rectangle getSkullUp() {
        return skullUp;
    }

    public Rectangle getSkullDown() {
        return skullDown;
    }

    public Rectangle getBarUp() {
        return barUp;
    }

    public Rectangle getBarDown() {
        return barDown;
    }

    public boolean collides(Bird bird) {
        if (position.x < bird.getX() + bird.getWidth()) {
            return (Intersector.overlaps(bird.getBoundingCircle(), barUp)
                    || Intersector.overlaps(bird.getBoundingCircle(), barDown)
                    || Intersector.overlaps(bird.getBoundingCircle(), skullUp) || Intersector
                        .overlaps(bird.getBoundingCircle(), skullDown));
        }
        return false;
    }

    public boolean isScored() {
        return isScored;
    }

    public void setScored(boolean b) {
        isScored = b;
    }
}
 */
