$(document).ready(() => {
    const $roundCompletedInput = $(".round-completed").first();

    if ($roundCompletedInput.val().toLowerCase() == "true") {
        setTimeout(() => {
            resetRound($roundCompletedInput.closest("form"));
        }, 2000);
    } else {
        $(".game-card").on("click", e => { e.preventDefault(); makeMove($(e.target)); return false; });
    }
});

function makeMove($clickedBtn) {
    const $form = $clickedBtn.closest("form");
    const $container = $form.closest(".div-game-board");

    $.ajax({
        data: $form.serialize(),
        type: $form.prop('method'),
        url: $clickedBtn.attr('formaction'),
        success: response => {
            $container.replaceWith(response);
        },
        error: () => {
            alert("Something went wrong!");
        }
    });
}

function resetRound($form) {
    const $container = $form.closest(".div-game-board");

    $.ajax({
        data: $form.serialize(),
        type: $form.prop('method'),
        url: "/game/reset-round",
        success: response => {
            $container.replaceWith(response);
        },
        error: () => {
            alert("Something went wrong!");
        }
    });
}