function shapes() {
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }

        changeUnits(unit) {
            this.units = unit;
        }

        convertUnits(num) {
            if (this.units === 'm') {
                return num /= 10;
            }
            if (this.units === 'mm') {
                return num *= 10
            };
            return num;
        }

        toString() {
            return `Figures units: ${this.units}`
        }
    }

    class Circle extends Figure {
        constructor(radius, units) {
            super(units);
            this._radius = radius;
        }

        get area() {
            this.radius = this.convertUnits(this._radius);
            return Math.PI * Math.pow(this._radius, 2);
        }

        toString() {
            return `Figures units: ${this.units} Area: ${this.area} - radius: ${this.radius}`
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);
            this._width = width;
            this._height = height;
        }

        get area() {
            this.width = this.convertUnits(this._width);
            this.height = this.convertUnits(this._height);
            return this.width * this.height;
        }

        toString() {
            return `Figures units: ${this.units} Area: ${this.area} - width: ${this.width}, height: ${this.height}`
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}


let classes = shapes();
let Figure = classes.Figure;
let Rectangle = classes.Rectangle;
let Circle = classes.Circle;

let c = new Circle(5);
console.log((c.area));
console.log(c.toString());

let r = new Rectangle(3, 4, 'mm');
console.log(r.area);
console.log(r.toString());
// r.changeUnits('cm');
// assert.equal(r.area, 12, "5");
// assert.equal(r.toString(), "Figures units: cm Area: 12 - width: 3, height: 4", "5");

// c.changeUnits('mm');
// console.log(c.area); // 7853.981633974483
// console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50