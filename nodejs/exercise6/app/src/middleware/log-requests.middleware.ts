import { ErrorRequestHandler, RequestHandler } from 'express';
import expressWinston from 'express-winston';
import { createLoggerOptions } from '../utils/logger-options';

export const traceLogger = (): RequestHandler => {
    return expressWinston.logger(createLoggerOptions());
};

export const errorLogger = (): ErrorRequestHandler => {
    return expressWinston.errorLogger(createLoggerOptions());
};
