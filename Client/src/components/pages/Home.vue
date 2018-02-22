<template>
  <div class="embed_content">
    <h1>Welcome to Article Page</h1>
    <iframe src="https://ecschooling.org/" name="frame_result" align="right" height="700" width="1300" style="border:4px solid black;"></iframe>
    <p><a href ="https://powerhookahus.com/" target="frame_result">Link 1</a></p>
    <p><a href ="https://www.hookah-shisha.com/" target="frame_result">Link 2</a></p>
    <p><a href ="http://www.ivc.edu/Pages/default.aspx" target="frame_result">Link 3 Education</a></p>
    <vue-good-table :columns="columns" :onClick="onClickFn" :rows="rows" />
  </div>
</template>
<script>
import Vue from 'vue'
import VueGoodTable from 'vue-good-table'
Vue.use(VueGoodTable)
export default {
  name: 'test',
  data () {
    return {
      columns: [
        {
          label: 'Article Type',
          field: 'articleType'
        },
        {
          label: 'Article Title',
          field: 'articleTitle'
        },
        {
          label: 'Article Link',
          field: 'articleLink'
        },
        {
          label: 'Article Description',
          field: 'articleDescription'
        },
        {
          label: 'Article Tag',
          field: 'articleTag'
        }
      ],
      rows: [
        {articleType: 'School', articleTitle: 'main page', articleLink: 'http://www.ivc.edu/Pages/default.aspx', articleDescription: 'Famous School', articleTag: 'education'},
        {articleType: 'Hookah', articleTitle: 'power', articleLink: 'https://www.hookah-shisha.com/', articleDescription: 'Famous', articleTag: 'entertainment'},
        {articleType: 'King', articleTitle: 'Competition', articleLink: 'https://powerhookahus.com/', articleDescription: 'Famous Brands', articleTag: 'entertainment'}
      ],
      onClickFn: function (row, index) {
        console.log(row)
        console.log(index)
      }
    }
  }
}
</script>
