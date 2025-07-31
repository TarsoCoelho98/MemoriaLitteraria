var snippets = null;

$(document).ready(function () {
    $('#btnSearch').on('click', function () {
        getSnippets();
    });

    $(document).on('click', '.btn-copy', function () {
        copyReference(this);
    });    

    $('#inpSearch').on('input', function () {
        checkSearchInput(this); 
    });
});

function checkSearchInput(element) {
    var value = $(element).val().trim();
    $('#btnSearch').prop('disabled', value.length < 2);

    if (value.length === 0) {
        const $container = $("#resultsContainer");
        $container.empty();

        if (!$('#contentContainer').is('[hidden]')) {
            hideContent();
        }
    }
}

function copyReference(element) {
    const reference = $(element).data('reference');
    const button = $(element);
    const tempInput = $('<input>');
    $('body').append(tempInput);
    tempInput.val(reference).select();
    document.execCommand('copy');
    tempInput.remove();
    button.html('<i class="bi bi-check-circle me-1"></i> Copiado!');
    setTimeout(function () {
        button.html('<i class="bi bi-clipboard me-1"></i> Copiar referência');
    }, 2000);
}

function getSnippets() {
    var search = $('#inpSearch').val();

    $.ajax({
        url: '/Home/GetSnippets',
        type: 'GET',
        data: { search: search },
        success: function (data) {
            const $container = $("#resultsContainer");
            $container.empty();

            if (!data || data.length === 0) {
                $container.append(`
                    <div class="card mb-3">
                        <div class="card-body">
                            <p class="card-text" style="text-align: justify;">Conteúdo não encontrado.</p>
                        </div>
                    </div>
                `);
                return;
            }

            snippets = data;

            $.each(snippets, function (i, snippet) {
                var content = snippet.shortContent.replace(/\\n/g, "<br>");
                var htmlClass = snippet.matchByStem ? "search-block" : "quote-block";
                var contentHtml = snippet.matchByStem
                    ? `<p class="quote-text">${content}</p>`
                    : `<p class="quote-text"><blockquote>${content}</blockquote></p>`;

                const cardHtml = `
                <div id="${snippet.localGuid}" class="card mb-3 shadow-sm border-0 card-snippet">
                    <div class="card-body">
                        <div class="${htmlClass}">
                            ${contentHtml}
                            <p class="quote-text mb-2">
                                <strong><i>${snippet.file.title}</i></strong>, escrito por ${snippet.author.name} e publicado em ${snippet.file.publicationYear}, capítulo "${snippet.section.title}".
                            </p>
                        </div>
                        <div class="d-flex flex-wrap gap-2 mt-3">
                            <button class="btn btn-outline-secondary btn-sm rounded-pill btn-copy" data-reference="${snippet.file.reference}">
                                <i class="bi bi-clipboard me-1"></i> Copiar referência
                            </button>
                            <button class="btn btn-outline-primary btn-sm rounded-pill btn-expand">
                                <i class="bi bi-arrows-angle-expand me-1"></i> Expandir
                            </button>
                            <a href="${snippet.file.sourceUrl}" class="btn btn-outline-primary btn-sm rounded-pill" download>
                                <i class="bi bi-download me-1"></i> Baixar
                            </a>
                        </div>
                    </div>
                </div>
                `;
                $container.append(cardHtml);
            });
        },
        error: function (error) {
            console.error('Erro na requisição AJAX:', error);
        }
    });
}
