function construction(worker) {
    if (worker.dizziness == true) {
        worker.levelOfHydrated += worker.weight * worker.experience * 0.1;
        worker.dizziness = false;
    }
    
    return worker;
}

console.log(construction({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}
));

console.log(construction({
    weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true
}
));