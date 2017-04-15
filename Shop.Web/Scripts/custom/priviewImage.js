function previewImage() {
    let file = $('input[type=file]')[0].files[0];

    if (!file) {
        return;
    }

    let preview = $('img')[0];
    let reader = new FileReader();

    reader.onloadend = () => preview.src = reader.result;
    reader.readAsDataURL(file);
}