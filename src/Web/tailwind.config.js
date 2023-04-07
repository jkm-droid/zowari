module.exports = {
    content: [
        '!**/{bin,obj,node_modules}/**',
        './Views/**/*.{cshtml,html}',
        './Pages/**/*.{cshtml,html}',
        './node_modules/flowbite/**/*.js'
    ],
    theme: {
        extend: {}
    },
    plugins: [
        require('flowbite/plugin')
    ],
}
