export const getConfigValue = (key: string): string | undefined => {
    return process.env[key];
};
