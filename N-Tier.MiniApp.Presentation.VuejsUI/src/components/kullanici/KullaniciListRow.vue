<template>
  <tr>
    <td>{{ kullanici.isim }}</td>
    <td>{{ kullanici.soyisim }}</td>
    <td>{{ kullanici.dogumtarihi }}</td>
    <td>
      <b-button variant="default"
                @click="onDetailsClick">Details</b-button>
    </td>
    <td>
      <b-button variant="success"
                @click="onUpdateClick">Update</b-button>
    </td>
    <td>
      <b-button variant="danger"
                @click="onDeleteClick">Delete</b-button>
    </td>
  </tr>
</template>
<script>
export default {
  name: 'KullaniciListRow',
    props: ['kullanici'],
    methods: {
      onDetailsClick() {
        this.$emit('details', this.kullanici.id);
      },
      onUpdateClick() {
        this.$emit('update', this.kullanici.id);
      },
      onDeleteClick() {
        this.$emit('delete', this.kullanici.id);
      }
    }
};
</script>
