# Toy Robot Simulator

The​ ​application​ ​is​ ​a​ ​simulation​ ​of​ ​a​ ​toy​ ​robot​ ​moving​ ​on​ ​a​ ​square​ ​tabletop,​ ​of dimensions​ ​5​ ​units​ ​x​ ​5​ ​units. There​ ​are​ ​no​ ​other​ ​obstructions​ ​on​ ​the​ ​table​ ​surface. The​ ​robot​ ​is​ ​free​ ​to​ ​roam​ ​around​ ​the​ ​surface​ ​of​ ​the​ ​table,​ ​but​ is ​prevented​ ​from falling​ ​to its​ ​destruction. - any​ ​movement​ ​that​ ​would​ ​result​ ​in​ ​the​ ​robot​ ​falling​ ​from​ ​the table​ ​will be ignored,​ ​however​ ​further​ ​valid​ ​movement​ ​commands​ ​must​ ​still​ ​be allowed.


## Instructions

This is a console application, it will open with a series of instructions and user will enter a series of commands that will be enacted in sequence once the GO command has been issued. GO will reset the robot and remoe it from the tabletop; any subsequent commands are treated afresh.

The​ ​application​ ​will accept ​any​ ​one​ ​of​ ​the​ ​following​ ​commands:

- PLACE​ _​x,y,f_ - ​will​ ​put​ ​the​ ​toy​ ​robot​ ​on​ ​the​ ​table​ ​in​ ​position​ _​X, Y_  ​and​ ​facing​ ​NORTH,​ ​SOUTH, EAST​ ​or​ ​WEST.
- MOVE - ​will​ ​move​ ​the​ ​toy​ ​robot​ ​one​ ​unit​ ​forward​ ​in​ ​the​ ​direction​ ​it​ ​is​ ​currently​ ​facing.
- LEFT - will​ ​rotate​ ​the​ ​robot​ ​90​ ​degrees​ ​anti-clockwise ​without changing its position.
- RIGHT - will​ ​rotate​ ​the​ ​robot​ ​90​ ​degrees​ ​clockwise ​without changing its position.
- REPORT - output the position and direction of the robot, e.g. 1,4,North.
- GO - execute the preceeding sequence of commands.
- QUIT - exit the program.

### Notes

- The​ ​origin​ ​(0,0)​ ​can​ ​be​ ​considered​ ​to​ ​be​ ​the​ ​SOUTH​ ​WEST​ ​most​ ​corner.
- The​ ​first​ ​valid​ ​command​ ​to​ ​the​ ​robot​ ​is​ ​a​ ​PLACE​ ​command,​ ​after​ that,​ ​any​ ​sequence of​ ​commands​ ​may​ ​be​ ​issued,​ ​in​ ​any​ ​order,​ ​including​ ​another​ ​PLACE​ ​command.​ ​The application​ will ignore ​all​ ​commands​ ​in​ ​the​ ​sequence​ ​until​ ​a​ ​valid​ ​PLACE command​ ​has​ ​been​ ​executed.
- A​ ​robot​ ​that​ ​is​ ​not​ ​on​ ​the​ ​table​ will ​ignore​ ​the​ ​MOVE,​ ​LEFT,​ RIGHT​ ​and​ ​REPORT commands.

### Constraints

- The​ ​toy​ ​robot​ ​must​ ​not​ ​fall​ ​off​ ​the​ ​table​ ​during​ ​movement.​ ​This​ ​also​ ​includes​ ​the​ ​initial placement​ ​of​ ​the​ ​toy​ ​robot.
- Any​ ​move​ ​that​ ​would​ ​cause​ ​the​ ​robot​ ​to​ ​fall​ ​must​ ​be​ ​ignored.

Eg.

~~~
PLACE​ ​0,0,NORTH
MOVE
REPORT
GO
Output:​ ​0,1,NORTH
~~~