-- Create job_candidate_attachments table
  create table if not exists public.job_candidate_attachments(
    id uuid not null, -- Unique identifier for each attachment
    job_candidate_id uuid not null, -- Unique identifier for each candidate
    file_name text not null, -- Attachment FileName
    file_path text not null, -- Attachment FilePath
    size int not null, -- Attachment Size
    extension text not null, -- Attachment Extension
    saved_file_name text not null, -- Saved File Name
    created_on timestamp with time zone not null,
    constraint pk_job_candidate_attachments primary key (id),
    constraint fk_job_candidate_attachments foreign key (job_candidate_id)
      references public.job_candidates(id) match simple
      on update no action
      on delete cascade
  );
