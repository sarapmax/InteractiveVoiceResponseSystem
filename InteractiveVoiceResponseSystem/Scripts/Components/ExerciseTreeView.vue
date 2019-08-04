<template>
    <ul>
        <node-tree :node="treeData[0]" :profession-id="professionId" :selected-node-id="selectedNodeId"></node-tree>
    </ul>
</template>

<script>
    import NodeTree from './NodeTree.vue'
    
    export default {
        props: ['treeData', 'professionId', 'selectedNodeId'],
        
        components: { NodeTree }
    }    
</script>
