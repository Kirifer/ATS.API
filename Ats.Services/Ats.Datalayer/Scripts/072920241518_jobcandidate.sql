do $$
begin
  -- Create recruitment table
  create table if not exists public.job_candidates (
    id uuid not null,
    csequence_no text not null, -- Job Candidate Number
    candidate_name text not null, -- Name
    job_role_id text not null, -- Job Role Number
    job_name text not null, -- Job Title (PUBLIC)
    source_tool int null, -- Sourcing Tool 
    assigned_hr int null, -- HR In-Charge
    candidate_cv text not null, -- Updated CV (file path or URL) (PUBLIC)
    candidate_email text not null, -- Email Address (PUBLIC)
    candidate_contact text not null, -- Contact Number (PUBLIC)
    asking_salary int not null, -- Asking Gross Salary (PUBLIC)
    salary_negotiable text not null, -- Negotiable (Yes/No) (PUBLIC)
    min_salary int not null, -- Minimum Negotiated Salary (PUBLIC)
    max_salary int null, -- Maximum Negotiated Salary
    notice_duration int not null, -- Availability (notice period) (PUBLIC)

    date_applied date not null, -- Date Applied
    initial_interview_schedule date not null, -- Initial Interview Schedule (PUBLIC)
    technical_interview_schedule date null, -- Technical Interview Schedule
    client_final_interview_schedule date null, -- Client/Final Interview Schedule
    background_verification date null, -- Background Verification

    application_status int null, -- Status (Application status)
    final_salary int null, -- Final Basic Salary
    allowance int null, -- Allowances
    honorarium text not null, -- Honorarium (Basic)
    job_offer date null, -- Job Offer (Date)
    candidate_contract date null, -- Job Contract (Date)
    remarks text not null,
   
    constraint pk_job_candidates primary key (id)
  );

  create index ix_job_candidates_id
    on public.job_candidates using btree
    (id asc nulls last);
end;
$$