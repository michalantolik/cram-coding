/*************************************************************************
 * CONTROLLER: AdminPost
 * VIEW:       AddPost
*************************************************************************/

function updateFormSubmissionDateTime() {

    let currentDateTimeIso = new Date().toISOString();
    $('input#FormSumbissionDateTimeUtc').val(currentDateTimeIso);

}

/*************************************************************************
 * CONTROLLER: AdminPost
 * VIEW:       Posts -> PostDetails
*************************************************************************/

function showPostDetails(controller, method, id) {

    window.location = `/${controller}/${method}/${id}`;

}
