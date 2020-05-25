<template>
  <div v-if="totalPages() > 0" class="pagination-wrapper">
    <span class="pagination-btn"><v-btn depressed color="indigo" @click="updatePage(currentPage - 1)"><v-icon>mdi-arrow-left</v-icon></v-btn></span>
    <div class="indigo">
      &nbsp;{{ currentPage +1 }} of {{ totalPages() }}&nbsp;
    </div>
    <span class="pagination-btn"><v-btn depressed color="indigo" @click="updatePage(currentPage + 1)"><v-icon>mdi-arrow-right</v-icon></v-btn></span>
  </div>
</template>

<script>
export default {
  name: 'Pagination',
  // eslint-disable-next-line vue/require-prop-types
  props: ['music', 'currentPage', 'pageSize'],
  methods: {
    updatePage (pageNumber) {
      if (pageNumber < 1) {
        pageNumber = 0
      } else if (pageNumber >= this.totalPages()) {
        pageNumber = this.totalPages() - 1
      }
      this.$emit('page:update', pageNumber)
    },
    totalPages () {
      return Math.ceil(this.music.length / this.pageSize)
    },
    showPreviousLink () {
      return this.currentPage === 0
    },
    showNextLink () {
      return this.currentPage === (this.totalPages() - 1)
    }
  }
}
</script>

<style>

</style>
