import { LoggerOptionsWithTransports } from 'express-winston';
import winston from 'winston';

export const createLoggerOptions = (): LoggerOptionsWithTransports => ({
    transports: [new winston.transports.Console()],
    format: winston.format.combine(
        winston.format.colorize(),
        winston.format.timestamp(),
        winston.format.align(),
        winston.format.printf((info) => {
            const { timestamp, level, message, ...args } = info;
            const ts = timestamp.slice(0, 19).replace('T', ' ');
            return `${ts} [${level}]:${message}\n${Object.keys(args).length ? JSON.stringify(args, null, 4) : ''}`;
        }),
    ),
});
