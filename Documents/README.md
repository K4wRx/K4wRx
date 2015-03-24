# API docs

### _*FrameAsObservable()_

##### Description

This method gets a Observable instance to listen to \*FrameArrived event.
It always creates new FrameReader instance.

`*` supports followings.
- AudioBeam
- Body
- BodyIndex
- Color
- Depth
- Infrared
- LongExposeInfrared
- MultiSource
- VisualGestureBuilder

All Kinect streams are [here](https://msdn.microsoft.com/ja-jp/library/microsoft.kinect.aspx).

##### Usage

```cs
BodyFrameAsObservable().Subscribe(BodyFrameEventArgs args -> console.log("Event arrived"));
```



### _BodyAsObservable()_

##### Description

This method provides Body instances from BodyFrameReader.
It always creates new FrameReader instance.

##### Usage

```cs
BodyAsObservable().Subscribe(bodies -> Console.Writeline(bodies[0].IsTracked));
```



### _TrackedBodyAsObservable()_

##### Description

This method provides Body instances which are tracked.
It is same as `BodyAsObservable().Subscribe(bodies -> bodies.Where(b -> b.TrackingId)).Select(b -> b);`
It always creates new FrameReader instance.

##### Usage

```cs
TrackedBodyAsObservable().Subscribe(bodies -> bodies);
```



### _TrackedBodyVGBFrameAsObservable()_

##### Description

This method provides some VGBFrame streams which are binding to tracked body's TrackingId.
The number of VGBFrame stream depends on maximum number of body.

##### Usage

```cs
TrackedBodyVGBFrameAsObservable().Subscribe((List<EventArgs>, List<Body>) -> ())

```



### _TrackedBody*GestureResultAsObservable()_

##### Description

This method provides GestureResults which are binding to tracked body's TrackingId.

`*` supports followings.
- Discrete
- Continuous

Detection technology overview is [here](https://msdn.microsoft.com/en-us/library/dn785523.aspx).

##### Usage

```cs
TrackedBodyDiscreteGestureResultAsObservable().Subscribe(List<Dictinary<String, GestureResult>>, List<Body> -> ())
```



### _*GestureResultAsObservable()_

#### Description

`*` supports followings.
- Discrete
- Continuous

#### Usage



### _*FrameReader#AsObservable()_

#### Description

Alias of `*FrameAsObservable()` with \*FrameReader.

#### Usage

```cs
var bodyFrameStream = bodyFrameReader.AsObservable();
```



### _KinectSensor#AsObservable()_

#### Description

This method provides stream of KinectSensor's status.
It supports following status as event.

- available
- open
- close

#### Usage

```cs
var sensorStream = kinectSensor.AsObservable();
sensorStream.Where(e -> e.status.IsAvailable).Select(_ -> DoSomething());
```



## Utilities

### _SubscribeThroughFrameSmoothing(EventArgs -> ())_

#### Description

#### Usage



### _SubscribeThroughFrameSmoothing(EventArgs -> EventArgs, EventArgs -> ())_

#### Description

#### Usage



### _SubscribeAsXXXXGestureResult(GestureResutl -> ())_

#### Description

#### Usage



## Planed

### _GestureAlias_

inspired by [this blog post](http://mtaulty.com/CommunityServer/blogs/mike_taultys_blog/archive/2014/08/22/kinect-for-windows-sdk-v2-mixing-with-some-reactive-extensions.aspx).

- Swipe
- Clap

### _CoodinateMapper_
