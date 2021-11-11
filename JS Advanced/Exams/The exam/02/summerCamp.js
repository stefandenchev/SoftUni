class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = { "child": 150, "student": 300, "collegian": 500 };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        if (!this.priceForTheCamp.hasOwnProperty(condition)) {
            throw new Error("Unsuccessful registration at the camp.");
        } else if (this.listOfParticipants.some(x => x.name == name)) {
            return `The ${name} is already registered at the camp.`;
        } else if (this.priceForTheCamp[condition] > money) {
            return `The money is not enough to pay the stay at the camp.`;
        } else {
            this.listOfParticipants.push({
                name: name,
                condition: condition,
                power: 100,
                wins: 0,
            })
            return `The ${name} was successfully registered.`;
        }
    }

    unregisterParticipant(name) {
        if (!this.listOfParticipants.some(x => x.name == name)) {
            throw new Error(`The ${name} is not registered in the camp.`);
        } else {
            this.listOfParticipants = this.listOfParticipants.filter(function (el) { return el.name != name; });
            return `The ${name} removed successfully.`;
        }
    }

    timeToPlay(typeOfGame, participant1, participant2) {
        if (typeOfGame == 'Battleship') {
            if (!this.listOfParticipants.some(x => x.name == participant1)) {
                throw new Error(`Invalid entered name/s.`);
            } else {
                var p = this.listOfParticipants.find(p => p.name == participant1);
                p.power += 20;
                return `The ${participant1} successfully completed the game ${typeOfGame}.`
            }
        } else {
            if (!this.listOfParticipants.some(x => x.name == participant1) || !this.listOfParticipants.some(x => x.name == participant2)) {
                throw new Error(`Invalid entered name/s.`);
            } else {
                var p1 = this.listOfParticipants.find(p => p.name == participant1);
                var p2 = this.listOfParticipants.find(p => p.name == participant2);
                if (p1.condition != p2.condition) {
                    throw new Error(`Choose players with equal condition.`);
                } else {
                    if (p1.power == p2.power) {
                        return `There is no winner.`
                    } else {
                        if (p1.power > p2.power) {
                            p1.wins++;
                            return `The ${p1.name} is winner in the game ${typeOfGame}.`
                        } else {
                            p2.wins++
                            return `The ${p2.name} is winner in the game ${typeOfGame}.`
                        }
                    }
                }
            }
        }

    }

    toString() {
        let result = [`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`];
        this.listOfParticipants.sort((a, b) => b.wins - a.wins);
        this.listOfParticipants.forEach((e) => result.push(`${e.name} - ${e.condition} - ${e.power} - ${e.wins}`));
        return result.join('\n');

    }
}

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp.toString());





