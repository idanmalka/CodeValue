import joi from 'joi';

export const idSchema = joi.string().required().length(36);
export const nameSchema = joi.string().required().min(3);
export const categoryIdSchema = joi.string().required().length(36);
export const itemsInStockSchema = joi.number().required();

export const newProductSchema = joi.object().keys({
    id: joi.forbidden(),
    name: nameSchema,
    categoryId: categoryIdSchema,
    itemsInStock: itemsInStockSchema,
});

export const existingProductSchema = joi.object().keys({
    id: idSchema,
    name: nameSchema,
    categoryId: categoryIdSchema,
    itemsInStock: itemsInStockSchema,
});
