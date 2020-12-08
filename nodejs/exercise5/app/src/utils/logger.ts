export class Logger {
    public log(...arg: unknown[]): void {
        console.log(...arg);
    }

    public debug(...arg: unknown[]): void {
        console.debug(...arg);
    }

    public warning(...arg: unknown[]): void {
        console.warn(...arg);
    }

    public error(error: Error): void {
        console.error(error);
    }
}

const logger = new Logger();
export { logger };
