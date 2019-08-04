<template>
    <li class="my-2">
        <a :href="url" class="text-lg" :class="{ 'font-semibold' : node.CNodeId === selectedNodeId }">{{ node.NodeIndex }}. {{ node.CNodeName }}</a>

        <ul class="ml-6" v-if="node.Children && node.Children.length">
            <node v-for="(child, index) in node.Children" 
                  :key="child.CNodeId" 
                  :node="child" 
                  :index="index + 1"
                  :profession-id="professionId"
                  :selected-node-id="selectedNodeId">
            </node>
        </ul>
    </li>
</template>

<script>
    export default {
        name: "node",
        
        props: ['node', 'index', 'professionId', 'selectedNodeId'],
        
        computed: {
            url() {
                return '/instructor/profession/show/' + this.professionId + '?nodeId=' + this.node.CNodeId
            }  
        }
    }
</script>

<style scoped>

</style>