import joi from 'joi';

export const idSchema = joi.string().required().length(36);
export const nameSchema = joi.string().required().min(3);

export const newCategorySchema = joi.object().keys({
    id: joi.forbidden(),
    name: nameSchema,
});

export const existingCategorySchema = joi.object().keys({
    id: idSchema,
    name: nameSchema,
});
