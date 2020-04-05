export class EnsureModuleLoadedOnceGuard {
    constructor(targetModule: any) {
        if (!targetModule) {
            return;
        }

        throw new Error(`${targetModule.constructor.name} has already been loaded. Import this module in ShellModule only`);
    }
}