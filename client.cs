$remapDivision[$remapCount]	= "Rapid Clicker & Rapid Fire";
$remapName[$remapCount]		= "Toggle Rapid Clicker";
$remapCmd[$remapCount]		= "rapidClick";
$remapCount++;

$remapName[$remapCount]		= "Toggle Rapidfire";
$remapCmd[$remapCount]		= "rapidFirev2";
$remapCount++;

$remapName[$remapCount]		= "Toggle Alt Rapid Clicker";
$remapCmd[$remapCount]		= "altRapidClick";
$remapCount++;


function rapidClick(%value)
{
	if(%value)
		rapidClickFunc();
	else
	{
		cancel($RapidClick::Schedule);
		mouseFire(0);
	}
}

function altRapidClick(%value)
{
	if(%value)
		altRapidClickFunc();
	else
	{
		cancel($AltRapidClick::Schedule);
		jet(0);
	}
}

function rapidFirev2(%value)
{
	if(!isObject(serverConnection.getControlObject().getMountedImage(0)))
		return;
	
	if(%value)
		rapidFireFunc();
	else
		cancel($RapidFire::Schedule);
}

function rapidClickFunc()
{
	$mvTriggerCount0 = !$mvTriggerCount0;
	commandToServer('activateStuff');
	$RapidClick::Schedule = schedule(32,0,rapidClickFunc);
}

function altRapidClickFunc()
{
	$mvTriggerCount4 = !$mvTriggerCount4;
	$AltRapidClick::Schedule = schedule(32,0,altRapidClickFunc);
}

function rapidFireFunc()
{
	scrollTools(1);
	scrollTools(-1);
	$RapidFire::Schedule = schedule(40,0,rapidFireFunc);
}
