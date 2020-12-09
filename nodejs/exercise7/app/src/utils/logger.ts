import winston, { Logger } from 'winston';
import { createLoggerOptions } from './logger-options';

export const createLogger = (name: string): Logger => {
    const options = createLoggerOptions();
    return winston.createLogger({
        transports: options.transports,
        format: options.format,
        defaultMeta: { name },
    });
};
