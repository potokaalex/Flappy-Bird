using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bird : MonoBehaviour
{
    private Vector2 velocity;
    private Vector2 acceleration;
    private bool isAlive = true;
    private float rotation;

    private void Start()
    {
        acceleration = new Vector2(0, 460);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
            velocity.y = -140;
    }

    private void FixedUpdate()
    {
        velocity += acceleration * Time.fixedDeltaTime;

        //if (velocity.y > 200)
        //{
        //    velocity.y = 200;
        //   Debug.Log(200);
        //}

        if (velocity.y < 0)//взлетаем
        {
            rotation += 600 * Time.fixedDeltaTime;

            if (rotation > 20)
            {
                rotation = 20;
            }
        }

        if (isFalling() || !isAlive)//падаем
        {
            //rotation -= 480 * Time.fixedDeltaTime;
            rotation -= 480 * Time.fixedDeltaTime;

            if (rotation < -90)
            {
                rotation = -90;
            }
        }

        transform.position -= new Vector3(0, velocity.y * Time.fixedDeltaTime / 25);

        transform.rotation = new Quaternion()
        {
            eulerAngles = new Vector3(0, 0, rotation)
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public bool isFalling()
    {
        return velocity.y > 70;
        //return velocity.y > 110;
    }
}

/*
EntityBase {
  id: player
  entityType: "player"

  property real upwardforce: -280  !
  property int resetX: 0 !
  property int resetY: 0 !

  width: collider.radius * 2
  height: collider.radius * 2

  signal gameOver()

  Component.onCompleted: reset()

  onGameOver: {
    spriteSequence.running = false
  }

  SpriteSequence {
    id: spriteSequence

    anchors.centerIn: parent

    Sprite {
      name: "idle"
      frameCount: 3
      frameRate: 10

      frameWidth: 34
      frameHeight: 24
      source: "../../assets/img/birdSprite.png"
    }
    rotation: wabbleX.running ? 0 : collider.linearVelocity.y / 10 ?
  }

  CircleCollider {
    id: collider

    radius: spriteSequence.height/2
    bodyType: Body.Dynamic
  }

  function reset() {
    player.x = resetX
    player.y = resetY
    collider.body.linearVelocity = Qt.point(0,0)
    activateWabbling()
    spriteSequence.running = true
  }

  function push() {
    wabbleX.stop()
    wabbleY.stop()
    audioManager.play(audioManager.idWING)
    collider.body.linearVelocity = Qt.point(0,0)
    var localForwardVector = collider.body.toWorldVector(Qt.point(0, upwardforce));
    collider.body.applyLinearImpulse(localForwardVector, collider.body.getWorldCenter());
  }

  NumberAnimation on x {running: false; id: wabbleX; duration: 4000; loops: Animation.Infinite; easing.type: Easing.CosineCurve}
  NumberAnimation on y {running: false; id: wabbleY; duration: 4000; loops: Animation.Infinite; easing.type: Easing.SineCurve}

  function activateWabbling() { !
    var wableVal = 25
    var rand = Math.random()
    var dir = (rand < 0.5 ? -wableVal/4*rand : wableVal/4*rand )
    wabbleX.from = player.x+dir
    wabbleX.to = player.x-dir
    wabbleX.start()

    rand = Math.random()
    dir = (rand < 0.5 ? -wableVal*rand : wableVal*rand )
    wabbleY.from = player.y+dir
    wabbleY.to = player.y-dir
    wabbleY.start()
  }
}
*/
/*
public class Bird {

    private Vector2 position;
    private Vector2 velocity;
    private Vector2 acceleration;

    private float rotation;
    private int width;
    private int height;
    
    private boolean isAlive;

    private Circle boundingCircle;

    public Bird(float x, float y, int width, int height) {
        this.width = width;
        this.height = height;
        position = new Vector2(x, y);
        velocity = new Vector2(0, 0);
        acceleration = new Vector2(0, 460);
        boundingCircle = new Circle();
        isAlive = true;
    }

    public void update(float delta) {

        velocity.add(acceleration.cpy().scl(delta));

        if (velocity.y > 200) {
            velocity.y = 200;
        }

        position.add(velocity.cpy().scl(delta));

        // Set the circle's center to be (9, 6) with respect to the bird.
        // Set the circle's radius to be 6.5f;
        boundingCircle.set(position.x + 9, position.y + 6, 6.5f);

        // Rotate counterclockwise
        if (velocity.y < 0) {
            rotation -= 600 * delta;

            if (rotation < -20) {
                rotation = -20;
            }
        }

        // Rotate clockwise
        if (isFalling() || !isAlive) {
            rotation += 480 * delta;
            if (rotation > 90) {
                rotation = 90;
            }

        }

    }

    public boolean isFalling() {
        return velocity.y > 110;
    }

    public boolean shouldntFlap() {
        return velocity.y > 70 || !isAlive;
    }

    public void onClick() {
        if (isAlive) {
            AssetLoader.flap.play();
            velocity.y = -140;
        }
    }
    
    public void die() {
        isAlive = false;
        velocity.y = 0;
    }
    
    public void decelerate() {
        acceleration.y = 0;
    }
    
    public void onRestart(int y) {
        rotation = 0;
        position.y = y;
        velocity.x = 0;
        velocity.y = 0;
        acceleration.x = 0;
        acceleration.y = 460;
        isAlive = true;
    }

    public float getX() {
        return position.x;
    }

    public float getY() {
        return position.y;
    }

    public float getWidth() {
        return width;
    }

    public float getHeight() {
        return height;
    }

    public float getRotation() {
        return rotation;
    }

    public Circle getBoundingCircle() {
        return boundingCircle;
    }

    public boolean isAlive() {
        return isAlive;
    }
}
*/