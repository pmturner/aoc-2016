var pathList = 'R4, R1, L2, R1, L1, L1, R1, L5, R1, R5, L2, R3, L3, L4, R4, R4, R3, L5, L1, R5, R3, L4, R1, R5, L1, R3, L2, R3, R1, L4, L1, R1, L1, L5, R1, L2, R2, L3, L5, R1, R5, L1, R188, L3, R2, R52, R5, L3, R79, L1, R5, R186, R2, R1, L3, L5, L2, R2, R4, R5, R5, L5, L4, R5, R3, L4, R4, L4, L4, R5, L4, L3, L1, L4, R1, R2, L5, R3, L4, R3, L3, L5, R1, R1, L3, R2, R1, R2, R2, L4, R5, R1, R3, R2, L2, L2, L1, R2, L1, L3, R5, R1, R4, R5, R2, R2, R4, R4, R1, L3, R4, L2, R2, R1, R3, L5, R5, R2, R5, L1, R2, R4, L1, R5, L3, L3, R1, L4, R2, L2, R1, L1, R4, R3, L2, L3, R3, L2, R1, L4, R5, L1, R5, L2, L1, L5, L2, L5, L2, L4, L2, R3';
var pathArray = pathList.split(', ');

var currentDirection = "N";
var currentMagnitude = 0;

var totals = {north: 0, south: 0, east: 0, west: 0};

var pathArrayWithDirections = pathArray.forEach(function(element) {
	var directionChange = element.substring(0,1);
	var magnitude = Number(element.substring(1));

	if (directionChange == "R") {
		switch (currentDirection) {
			case "N":
				currentDirection = "E";
				totals.east += magnitude;
				break;
			case "S":
				currentDirection = "W";
				totals.west += magnitude;
				break;
			case "E":
				currentDirection = "S";
				totals.south += magnitude;
				break;
			case "W":
				currentDirection = "N";
				totals.north += magnitude;
				break;
		}
	} else {
		switch (currentDirection) {
			case "N":
				currentDirection = "W";
				totals.west += magnitude;
				break;
			case "S":
				currentDirection = "E";
				totals.east += magnitude;
				break;
			case "E":
				currentDirection = "N";
				totals.north += magnitude;
				break;
			case "W":
				currentDirection = "S";
				totals.south += magnitude;
				break;
		}
	}
});

var directionX = Math.abs(totals.north - totals.south);
var directionY = Math.abs(totals.east - totals.west);

console.log(directionX + directionY);