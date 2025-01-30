/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./**/*.{razor,html,cshtml,js}",
        "./Pages/**/*.{razor,html,cshtml,js}",
        "./Shared/**/*.{razor,html,cshtml,js}",
        "./Components/**/*.{razor,html,cshtml,js}"
    ],
    theme: {
        extend: {},
    },
    plugins: [],
};
