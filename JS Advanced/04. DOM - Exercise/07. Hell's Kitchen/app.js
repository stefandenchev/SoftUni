function solve2() {
    document.querySelector('#btnSend').addEventListener('click', onClick);

    function onClick() {
        let arr = JSON.parse(document.querySelector('#inputs textarea').value);
        let objWinner = findBestRestaurant(arr);
        document.querySelector('#bestRestaurant>p').textContent = getMsgRest(objWinner);
        document.querySelector('#workers>p').textContent = getMsgEmp(objWinner.workers);
    }

    function getMsgRest(objWinner) {
        return `Name: ${objWinner.name} Average Salary: ${objWinner.avgSalary.toFixed(2)} Best Salary: ${objWinner.maxSalary.toFixed(2)}`;
    }

    function getMsgEmp(workers) {
        return workers.map(w => `Name: ${w.worker} With Salary: ${w.salary}`).join(' ');
    }

    function findBestRestaurant(arr) {
        let resultRestaurants = arr.reduce((acc, e) => {
            let [restaurant, ...workers] = e.split(/(?: - )|(?:, )/g);
            workers = workers.map(w => {
                let [worker, salary] = w.split(' ');
                return {
                    worker: worker,
                    salary: +salary
                };
            });
            let foundRestraunt = acc.find(r => r.name === restaurant);
            if (foundRestraunt) {
                foundRestraunt.workers = foundRestraunt.workers.concat(workers);
            } else {
                acc.push({
                    name: restaurant,
                    workers: workers
                });
            }
            return acc;
        }, []);

        resultRestaurants.forEach((el, idx) => {
            el.inputOrder = idx;
            el.avgSalary = el.workers.reduce((acc, el) => acc + el.salary, 0) / el.workers.length;
            el.maxSalary = Math.max(...el.workers.map(w => w.salary));
        });

        resultRestaurants.sort((a, b) => b.avgSalary - a.avgSalary || a.inputOrder - b.inputOrder);
        let bestRestaurant = resultRestaurants[0];
        bestRestaurant.workers.sort((a, b) => b.salary - a.salary);

        return bestRestaurant;
    }
}

/*--------------------------------------------------------------*/


function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);
    let input = document.querySelector('#inputs > textarea');
    const bestRestaurantInput = document.querySelector('#bestRestaurant > p');
    const workersInput = document.querySelector('#workers > p');

    function onClick() {
        const arr = JSON.parse(input.value);

        let restaurants = {};
        arr.forEach((line) => {
            const tokens = line.split(' - ');
            const name = tokens[0];
            const workersArr = tokens[1].split(', ');
            let workers = [];

            for (const worker of workersArr) {
                const workerTokens = worker.split(' ');
                const salary = +workerTokens[1];
                workers.push({
                    name: workerTokens[0],
                    salary  // Number(workerTokens[1])
                })
            }

            if (restaurants[name]) {
                workers = workers.concat(restaurants[name].workers);
            }
            workers.sort((worker1, worker2) => worker2.salary - worker1.salary);
            const bestSalary = workers[0].salary;
            const averageSalary = workers
                .reduce((sum, worker) => sum + worker.salary, 0) / workers.length;

            restaurants[name] = {
                workers,
                averageSalary,
                bestSalary
            }
        });

        let bestRestaurantSalary = 0;
        let bestRestaurant = undefined;

        for (const name in restaurants) {
            if (restaurants[name].averageSalary > bestRestaurantSalary) {
                bestRestaurant = {
                    name,
                    workers: restaurants[name].workers,
                    bestSalary: restaurants[name].bestSalary,
                    averageSalary: restaurants[name].averageSalary,
                }
                bestRestaurantSalary = restaurants[name].averageSalary;
            }
        }

        bestRestaurantInput.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

        let workersResult = [];
        bestRestaurant.workers.forEach(worker => {
            workersResult.push(`Name: ${worker.name} With Salary: ${worker.salary}`);
        })

        workersInput.textContent = workersResult.join(' ');
    }
}