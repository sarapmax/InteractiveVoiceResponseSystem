<template>
    <div class="flex justify-between px-4 py-2 rounded mb-2 border-2 hover:border-2 hover:border-blue-500 cursor-pointer" 
         :class="{ 'border-blue-500' : question.Selected, 'border-gray-300' : !question.Selected }">
        <div class="w-full" @click="showModal = true">
            <div>
                <div class="flex justify-between items-center">
                    <h3 class="text-xl font-semibold">{{ question.QuestionIndex.CQuestion }}</h3>
                    <div>
                        <svg v-if="question.Selected" class="text-blue-500 h-8 w-8" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"></path><polyline points="22 4 12 14.01 9 11.01"></polyline></svg>
                    </div>
                </div>
                <ul v-if="question.QuestionMode.CQuestionType === '1'" class="flex mt-2">
                    <li class="mr-4"
                        v-for="choice in question.QuestionIndex.QuestionSelectionIndexes">
                        <span v-if="choice.BCaseSelect" class="text-lg flex items-center text-blue-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><polyline points="9 11 12 14 22 4"></polyline><path d="M21 12v7a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h11"></path></svg>
                            <span class="ml-1 font-semibold">{{ choice.CSelection }}</span>
                        </span>
                        <span v-else class="text-lg flex items-center">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><rect x="3" y="3" width="18" height="18" rx="2" ry="2"></rect></svg>
                            <span class="ml-1">{{ choice.CSelection }}</span>
                        </span>
                    </li>
                </ul>
                <div v-if="question.QuestionMode.CQuestionType === '2'" class="flex mt-2">
                    <span class="text-lg text-gray-700">{{ question.QuestionIndex.CAnswer }}</span>
                </div>
            </div>
            <div v-if="question.VPAnswer" class="bg-gray-200 px-4 py-2 rounded mt-4">
                <p class="inline-flex items-center text-blue-500 font-semibold">
                    <svg class="h-4 w-4" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M12 1a3 3 0 0 0-3 3v8a3 3 0 0 0 6 0V4a3 3 0 0 0-3-3z"></path><path d="M19 10v2a7 7 0 0 1-14 0v-2"></path><line x1="12" y1="19" x2="12" y2="23"></line><line x1="8" y1="23" x2="16" y2="23"></line></svg>
                    <span class="ml-2 text-lg">{{ question.VPAnswer.Answer }}</span>
                </p>
            </div>
        </div>

        <vue-tailwind-modal :showing="showModal" @close="showModal = false">
            <edit-question :question="question" @questionUpdated="showModal = false"></edit-question>
        </vue-tailwind-modal>
    </div>
</template>

<script>
    import VueTailwindModal from 'vue-tailwind-modal'
    import EditQuestion from './EditQuestion.vue'
    
    export default {
        props: ['question'],
        
        components: {
            VueTailwindModal,
            EditQuestion
        },
        
        data() {
            return {
                showModal: false
            }
        }
    }
</script>

<style scoped>

</style>