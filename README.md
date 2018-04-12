# HashedWheelTimer
HashedWheelTimer implemented in C# and .NetCore inspired by io.netty.util.HashedWheelTimer

## What is HashedWheelTimer

HashedWheelTimer is based on George Varghese and Tony Lauck's paper, [Hashed and Hierarchical Timing Wheels: data structures to efficiently implement a timer facility](http://cseweb.ucsd.edu/users/varghese/PAPERS/twheel.ps.Z). It is a timer optimized for approximated I/O timeout scheduling.

![](./hwt.png)