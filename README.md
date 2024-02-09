# Melfa.Robot

This is a implementation of [Mitsubishi Electronics Factory Automation (MELFA)
](https://www.mitsubishielectric.com/fa/) robot R-protocol client in C#.

The R-protocol is described in **BFP-A4288**, the version this project consult is 
**BFP-A4288-V (2018/11/15)**.

# Configure the robot controller

Go to "Parameter -> Communication Parameterr -> Ethernet", Check the "Device & Line" tab.

Make sure one of OPT11 ~ OPT19 is configured as `Server`. For example:
- Mode (NETMODE): 1 - Server
- Port (NETPORT): 12345 # This is the port used to connect to the controller
- Protocol (OPCE11): 0 - No-procedure # This is probably irrelevant
- Exit Code (NETTERM): 0 - No-included
- Packet Type (CTERME): 0 - CR

# Usage
## Create the robot object
```C#
var robot = new MelfaRobot("localhost", 10001, 1); // use the port configured above
robot.Connect();
var info = robot.Open("ClientName");
```

## Do something with the robot
```C#
robot.OperationEnabled = true; // CTRLON
robot.ServoOn = true; // SRVON
robot.Override = 10; // OVRD=10
robot.Execute("MOV P1");
```

## Load a program and run
```C#
robot.RunProgram("blah");
```

## Clean-up
```C#
robot.Close();
robot.Disconnect();
robot.Dispose();
```

# TODO
- Finish implement of all functionalities
- Add more error log items (which is tedious...)

# Disclaimer

**The author of this software is not affiliated with
[Mitsubishi Electronics Factory Automation (MELFA)
](https://www.mitsubishielectric.com/fa/) in any way. All
trademarks and registered trademarks are property of their respective owners,
and company, product and service names mentioned in this readme or appearing in
source code or other artifacts in this repository are used for identification
purposes only.**

**Use of these names does not imply endorsement by either [Mitsubishi Electronics Factory Automation (MELFA)
](https://www.mitsubishielectric.com/fa/).**