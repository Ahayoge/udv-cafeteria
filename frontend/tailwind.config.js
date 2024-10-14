/** @type {import('tailwindcss').Config} */
export default {
    content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"],
    theme: {
        colors: {
            mint: {
                100: "#00C08B",
                80: "#33dbb0",
                60: "#66e5c5",
                40: "#98ecd7",
                20: "#cdf6ea",
            },
            graphite: {
                100: "#0B2027",
                80: "#3a4d52",
                60: "#6c787c",
                40: "#9ca5a9",
                20: "#cfd2d2",
            },
            violet: {
                100: "#712181",
                80: "#8d4c9b",
                60: "#a979b3",
                40: "#c7a6cd",
                20: "#e3d3e5",
            },
            white: "#f8f9fa",
            yellow: "#D8F69A",
            lv: "#DCCFEC",
            db: "#003B4C",
        },
        fontFamily: {
            hero: ["Hero", "system-ui", "sans-serif"],
            golos: ["Golos Text", "system-ui", "sans-serif"],
        },
    },
    plugins: [],
};
