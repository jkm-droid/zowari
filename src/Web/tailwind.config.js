/** @type {import('tailwindcss').Config} */
module.exports = {
  purge: {
    enabled: true,
    content: [
      '!**/{bin,obj,node_modules}/**',
      '**/*.{cshtml,html}',
    ]
  },
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {},
  },
  plugins: [],
}
