<template>
    <div class="px-1">
        <h3 class="mb-4 text-xl font-semibold">New Question</h3>
        <div class="mb-4">
            <span class="text-gray-700">Question Type</span>
            <div class="mt-2">
                <label class="inline-flex items-center">
                    <input type="radio" class="form-radio" v-model="questionType" value="1">
                    <span class="ml-2">Selection</span>
                </label>
                <label class="inline-flex items-center ml-6">
                    <input type="radio" class="form-radio" v-model="questionType" value="2">
                    <span class="ml-2">Fill Out</span>
                </label>
            </div>
        </div>
        <div class="mb-4">
            <label class="block">
                <span class="text-gray-700">Question Title</span>
                <input type="text" class="form-input mt-1 block w-full" v-model="questionTitle">
            </label>
        </div>
        <div v-if="questionType" class="mb-4 bg-gray-200 px-4 py-4 rounded">
            <div v-if="questionType == 1">
                <label class="text-lg text-gray-700">Selection Answer</label>
                <div v-for="choice in selectionChoices" class="flex mt-2 mb-2">
                    <input type="text" class="form-input mt-1 w-4/5" v-model="choice.answer">
                    <label class="w-1/5 flex items-center ml-4">
                        <input type="radio" class="form-checkbox" v-model="choice.correct" :value="true">
                        <span class="ml-2">Correct</span>
                    </label>
                </div>
                <div>
                    <a @click="addMoreSelectionChoice" class="inline-flex items-center text-blue-500 text-sm font-semibold hover:text-blue-700 cursor-pointer">
                        <svg class="h-4 w-4" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><line x1="12" y1="5" x2="12" y2="19"></line><line x1="5" y1="12" x2="19" y2="12"></line></svg>
                        <span class="ml-1">Add More</span>
                    </a>
                    <a @click="removeLastSelectionChoice" v-if="selectionChoices.length > 1" class="inline-flex ml-2 items-center text-blue-500 text-sm font-semibold hover:text-blue-700 cursor-pointer">
                        <svg class="h-4 w-4" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><line x1="5" y1="12" x2="19" y2="12"></line></svg>
                        <span>Remove</span>
                    </a>
                </div>
            </div>
            <div v-if="questionType == 2">
                <label class="block">
                    <span class="text-lg text-gray-700">Fill Out Answer</span>
                    <input type="text" class="form-input mt-1 block w-full" v-model="fillOutAnswer">
                </label>
            </div>
        </div>
        <div>
            <button @click="post" class="button button-blue">Submit</button>
        </div>
    </div>
</template>

<script>
    export default {
        props: ['nodeId'],
        
        data() {
            return {
                questionType: null,
                questionTitle: null,
                fillOutAnswer: null,
                selectionChoices: [
                    { answer: null, correct: false }
                ]
            }
        },
        
        methods: {
            post() {
                axios.post('/instructor/api/question/store', {
                    nodeId: this.nodeId,
                    questionType: this.questionType,
                    questionTitle: this.questionTitle,
                    fillOutAnswer: this.fillOutAnswer,
                    selectionChoices: this.selectionChoices
                }).then((response) => {
                    this.$emit('questionCreated')
                })
            },
            
            addMoreSelectionChoice() {
                this.selectionChoices.push({ answer: null, correct: false })
            },

            removeLastSelectionChoice() {
                this.selectionChoices.pop()
            }
        }
    }
</script>

<style scoped>

</style>