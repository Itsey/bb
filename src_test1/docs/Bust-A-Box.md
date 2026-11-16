# Bust-A-Box



## Goal

A turret is at the base of a rectangular view, up the view there are blocks of varying strengths.  The blocks descend at a regular interval and a ball is fired at the blocks.  It bounces off walls and the blocks but falls through the floor.  The balls strength can be increased which is how it defeats stronger blocks. 

## Terminology

| Term        | Definition                                                   |
| ----------- | ------------------------------------------------------------ |
| Box         | A breakable block that has a position on screen and has a BoxStrength.  At zero BoxStrength it is removed. |
| BoxStrength | The amount of ball power required to destroy a Box           |
| Ball        | The missile that impacts Boxes with a given BallPower, note this is a singular Ball. |
| BallPower   | The amount of BoxStrength reduced when a Ball hits a Box     |
| BallChain   | A collection of Balls that follow each other.                |
| Perimeter   | The bounding edges of the zone, including the right top and left sides only. |
| BaseLine    | The bottom edge of the zone.                                 |
| Turret      | The launch position for the Ball.                            |
| Zone        | The entire gaming area.                                      |



## Artistic style

```
Using a pixel art space theme, which has neon colours and a clearly futuristic look.
```



## Design Decisions

🗺️ The ball should speed up if it has been in flight for more than a few seconds.  How long and how fast does that scale.

🗺️ How will the blocks positioning be determined? random ? pseudo random ? manual ?

🗺️ What are the game elements - how does one increase block strength and ball power

🗺️ How is scoring kept

🗺️ Lives how is lifetime management managed

🗺️ Ugrade - tracer line, double barrels, backing blocks



## Beach

🎯Basic ball launch and bounce mechanics.  First release.

#### B.1 ✅

* A turret is visible at the base of the game. ✅
* A ball is launched and moves across the screen. ✅



#### B.2 ✅

* The ball bounces off the side walls and top.  It exits the map through the bottom. ✅
* Ball bounce implementation uses standard physics to appear to bounce naturally. ✅



#### B.3 ✅

* The turret can be rotated to change the initial direction of the ball.✅

* Ball launch is controlled on launch key or trigger action, after direction set.✅

  

#### B.4 

* Tidy up textures on wall & turret.  ❌ Deferred due to tooling issues.
* 🐞 SpriteSheet is not the way to go, redesign turret sprite to allow rotation. ✅



## Cricket

🎯 Blocks exist and can be destroyed.   Ball damage is 1 block strength is 1.

#### C.1

* Single block is placed on the screen, ball bounces off the block.

#### C.2

* Single block is placed on the screen, destroyed when hit by the ball.  Ball bounces off the block when it is there and not when it is not there.

#### C.3

* Having all balls out of play makes another block / row of blocks appear
* Block can only appear in a configurable top portion of the screen





## Dodge

🎯 Blocks move downward.



## Foot

🎯 BlockStrength and BallPower introduced, mechanism for gaining BallPower and BlockStrength increasing is added.

🗺️ Design decision needed.



## Golf

## Hand

## Kick

## Lacrosse

## Medicine

## Net

## Pool

## Rugby

## Squash

## Tennis

## VolleyWe