const { VueLoaderPlugin } = require('vue-loader')

module.exports = {
    entry: {
        // This index.js is main file which should include all other modules 
        app: ['./scripts/index.js']
    },
    output: {
        // this says : Compiled file goes to [name].js ie. app.js in my case
        path: __dirname + "/wwwroot/js/dist/",
        filename: '[name].js'
    },
    devtool: 'source-map',
    module: {
        // modules contains Special compilation rules 
        rules: [
            { test: /\.js$/, loader: 'babel-loader', exclude: /node_modules/ },
            { test: /\.(png|woff|woff2|eot|ttf|svg)$/, loader: 'url-loader?limit=100000' },
            { test: /\.css$/,
                use: [ 
                    { loader: "css-loader" }
                ]
            },
            {
                test: /\.vue$/,
                use: 'vue-loader'
            }
        ]
    },
    plugins: [
        new VueLoaderPlugin()
    ]
};