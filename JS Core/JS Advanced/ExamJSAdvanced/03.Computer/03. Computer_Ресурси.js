class Computer {
    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory = ramMemory;
        this.cpuGHz = cpuGHz;
        this.hddMemory = hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];
    }

    installAProgram(name, requiredSpace) {
        if(requiredSpace > this.hddMemory) {
            throw Error("There is not enough space on the hard drive");          
        }

        let obj = {name, requiredSpace};
        this.hddMemory -= requiredSpace;

        this.installedPrograms.push(obj);

        return obj;
    }

    uninstallAProgram(name) {
        let currentProgram = this.installedPrograms
            .filter(x => x.installedPrograms.name === name);

        if(!currentProgram) {
            throw Error("Control panel is not responding");
        }

        let currentCapacity = currentProgram.requiredSpace;

        this.installedPrograms = this.installedPrograms
            .filter(x => x.installedPrograms.name !== name);
        
        this.hddMemory += currentCapacity;

        return this.installedPrograms;
    }

    openAProgram(name) {
        let currentProgram = this.installedPrograms
            .filter(x => x.installedPrograms.name === name);

            if(!currentProgram) {
                throw Error(`The ${name} is not recognized`);
            }

        let calcRam;

        let ram = (this.installedPrograms[name].requiredSpace / this.ramMemory) * 1.5
        let cpu = ((this.installedPrograms[name].requiredSpace / this.cpuGHz) / 500) * 1.5;
    }
}