/*************************************************************************
 * CONTROLLER: Admin
 * VIEW:       AddPost
*************************************************************************/

function updateFormSubmissionDateTime() {

    let currentDateTimeIso = new Date().toISOString();
    $('input#FormSumbissionDateTimeUtc').val(currentDateTimeIso);

}

/*************************************************************************
 * CONTROLLER: Admin
 * VIEW:       Posts -> PostDetails
*************************************************************************/

function showPostDetails(controller, method, id) {

    window.location = `/${controller}/${method}/${id}`;

}
