<template>
    <div>
        <div v-if="node">
            <div class="flex justify-between items-center py-4 mb-2">
                <h2 class="text-2xl font-semibold">{{ node.CNodeName }}</h2>
                <button class="button button-blue" @click="showModal = true">New Question</button>
            </div>
            <div class="mb-4">
                <question-listing v-for="question in node.SelectionQuestions" :key="question.CSelectionQuestionId" :question="question"></question-listing>
            </div>
            <vue-tailwind-modal :showing="showModal" @close="showModal = false">
                <create-question :node-id="node.CNodeId" @questionCreated="showModal = false"></create-question>
            </vue-tailwind-modal>
        </div>
        <div v-else class="py-4">
            <h2 class="text-2xl font-semibold">Please select the node</h2>
        </div>
    </div>
</template>

<script>
    import VueTailwindModal from 'vue-tailwind-modal'
    import CreateQuestion from './CreateQuestion.vue'
    import QuestionListing from './QuestionListing.vue'
    
    export default {
        props: ['node'],
        
        components: {
            VueTailwindModal,
            CreateQuestion,
            QuestionListing
        },
        
        data() {
            return {
                showModal: false,
            }
        }
    }
</script>

<style scoped>

</style>