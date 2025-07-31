$(document).ready(function () {
    $('#btnBack').on('click', function () {
        hideContent();
    });

    $(document).on('click', '.btn-expand', function () {
        expandContent(this);
    });
});

function hideContent() {
    $('#contentContainer').attr('hidden', true);
    $('#resultsContainer').removeAttr('hidden');
    $('#btnBack').attr('hidden', true);
    $('#btnSearch').removeAttr('hidden');
    $('#inpSearch').prop('disabled', false);
}
function expandContent(element) {
    var cardId = $(element).closest('.card-snippet').attr('id');
    var snippet = snippets.find(s => s.localGuid === cardId);
    var content = snippet.section.content.replace(/\\n/g, "<br><br>");
    $('#pContent').html(content);
    $('#resultsContainer').attr('hidden', true);
    $('#contentContainer').removeAttr('hidden');
    $('#btnSearch').attr('hidden', true);
    $('#btnBack').removeAttr('hidden');
    $('#inpSearch').prop('disabled', true);
}