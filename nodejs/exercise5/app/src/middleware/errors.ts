import { NextFunction, Request, Response } from 'express';
import { logger } from '../utils/logger';

export function logErrors(err: Error, req: Request, res: Response, next: NextFunction): void {
    logger.error(err);
    next(err);
}

export function clientErrorHandler(err: Error, req: Request, res: Response, next: NextFunction): void {
    if (!req.xhr) {
        res.status(500).send({ error: err });
    } else {
        next(err);
    }
}

export function errorHandler(err: Error, req: Request, res: Response): void {
    res.status(500);
    res.render('error', { error: err });
}
