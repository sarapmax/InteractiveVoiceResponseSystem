<template>
    <div class="px-1">
        <h3 class="mb-4 text-xl font-semibold">Edit Question</h3>
        <div class="mb-4">
            <span class="text-gray-700">Select this question</span>
            <div class="mt-2">
                <div>
                    <label class="inline-flex items-center">
                        <input type="checkbox" class="form-checkbox" v-model="selected" checked>
                        <span class="ml-2">Yes</span>
                    </label>
                </div>
            </div>
        </div>
        <div class="mb-4">
            <label class="block">
                <span class="text-gray-700">Virtual Person Answer</span>
                <input type="text" class="form-input mt-1 block w-full" v-model="answer">
            </label>
        </div>
        <div>
            <button @click="submit" class="button button-blue">Submit</button>
        </div>
    </div>
</template>

<script>
    export default {
        props: ['question'],
        
        data() {
            return {
                answer: this.question.VPAnswer ? this.question.VPAnswer.Answer : '',
                selected: this.question.Selected
            }
        },
        
        methods: {
            submit() {
                axios.post('/instructor/api/question/update', {
                    nodeId: this.question.CNodeId,
                    cSelectionQuestionID: this.question.CSelectionQuestionId,
                    answer: this.answer,
                    selected: this.selected
                }).then((response) => {
                    this.$emit('questionUpdated')
                })
            }
        }
    }
</script>

<style scoped>

</style>