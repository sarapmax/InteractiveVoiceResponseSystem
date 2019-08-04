window.Vue = require('vue/dist/vue.js');
window.axios = require('axios');

window.axios.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';

Vue.component('exercise-tree-view', require('./Components/ExerciseTreeView.vue').default);
Vue.component('exercise-question', require('./Components/Instructor/ExerciseQuestion.vue').default);

Vue.prototype.$eventBus = new Vue();

const app = new Vue({
    el: '#app',
});
