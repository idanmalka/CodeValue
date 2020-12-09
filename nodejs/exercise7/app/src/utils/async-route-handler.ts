import { NextFunction, Request, Response } from 'express';

type RouteHandler<T = void> = (req: Request, res: Response, next: NextFunction) => T;

export const asyncWrapper = (delegate: RouteHandler<Promise<any>>): RouteHandler => {
    return (req, res, next?) => {
        delegate(req, res, next)
            .then((result) => res.send(result))
            .catch(next);
    };
};
