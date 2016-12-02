var pathList = 'R4, R1, L2, R1, L1, L1, R1, L5, R1, R5, L2, R3, L3, L4, R4, R4, R3, L5, L1, R5, R3, L4, R1, R5, L1, R3, L2, R3, R1, L4, L1, R1, L1, L5, R1, L2, R2, L3, L5, R1, R5, L1, R188, L3, R2, R52, R5, L3, R79, L1, R5, R186, R2, R1, L3, L5, L2, R2, R4, R5, R5, L5, L4, R5, R3, L4, R4, L4, L4, R5, L4, L3, L1, L4, R1, R2, L5, R3, L4, R3, L3, L5, R1, R1, L3, R2, R1, R2, R2, L4, R5, R1, R3, R2, L2, L2, L1, R2, L1, L3, R5, R1, R4, R5, R2, R2, R4, R4, R1, L3, R4, L2, R2, R1, R3, L5, R5, R2, R5, L1, R2, R4, L1, R5, L3, L3, R1, L4, R2, L2, R1, L1, R4, R3, L2, L3, R3, L2, R1, L4, R5, L1, R5, L2, L1, L5, L2, L5, L2, L4, L2, R3';
var pathArray = pathList.split(', ');

var currentDirection = "N";
var coordinateArray = [];
var currentCoordinate = {x: 0, y: 0};

pathArray.forEach(function(element) {
	var directionChange = element.substring(0,1);
	var magnitude = Number(element.substring(1));
	var change = "";

	if (directionChange == "R") {
		switch (currentDirection) {
			case "N":
				currentDirection = "E";
				change = "x";
				break;
			case "S":
				currentDirection = "W";
				change = "-x"; 
				break;
			case "E":
				currentDirection = "S";
				change = "-y"; 
				break;
			case "W":
				currentDirection = "N";
				change = "y";
				break;
		}
	} else {
		switch (currentDirection) {
			case "N":
				currentDirection = "W";
				change = "-x"; 
				break;
			case "S":
				currentDirection = "E";
				change = "x";
				break;
			case "E":
				currentDirection = "N";
				change = "y";
				break;
			case "W":
				currentDirection = "S";
				change = "-y"; 
				break;
		}
	}

	for (var i = 0; i < magnitude; i++) {
		switch (change) {
			case "x":
				var coordinateStep = {x: currentCoordinate.x += 1, y: currentCoordinate.y};
				break;
			case "-x":
				var coordinateStep = {x: currentCoordinate.x -= 1, y: currentCoordinate.y};
				break;
			case "y":
				var coordinateStep = {x: currentCoordinate.x, y: currentCoordinate.y += 1};
				break;
			case "-y":
				var coordinateStep = {x: currentCoordinate.x, y: currentCoordinate.y -= 1};
				break;
		}

		coordinateArray.push(coordinateStep);
	}
});

var arrayToCheck = [];
var duplicateSet = [];

coordinateArray.forEach(function(element) {
	var addToCheck = 1;

	for (var j = 0; j < arrayToCheck.length; j++) {
		if (JSON.stringify(element) === JSON.stringify(arrayToCheck[j])) {
			duplicateSet.push(element);
			addToCheck = 0;
		} 
	}

	if (addToCheck) {
		arrayToCheck.push(element);
	}
});

console.log(Math.abs(duplicateSet[0].x) + Math.abs(duplicateSet[0].y));