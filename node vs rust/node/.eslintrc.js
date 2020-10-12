module.exports = {
    env: {
        commonjs: true,
        es2021: true,
        node: true
    },
    extends: [
        'airbnb-base'
    ],
    parserOptions: {
        ecmaVersion: 12
    },
    rules: {
        indent: ['error', 4],
        semi: ['error', 'never'],
        quotes: ['error', 'single'],
        'comma-dangle': ['error', 'never'],
        'arrow-parens': ['error', 'as-needed'],
        'no-underscore-dangle': ['warn', { allowAfterThis: true }],
        'no-console': 'off'
    }
}
