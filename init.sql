CREATE TABLE list(
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT now()
);

CREATE TABLE tasks(
    id SERIAL PRIMARY KEY,
    list_id INT,
    title VARCHAR(255) NOT NULL,
    description VARCHAR(255),
    is_done BOOLEAN DEFAULT false,
    priority INT,
    is_pinned BOOLEAN DEFAULT false,
    color VARCHAR(20),
    due_date DATE,
    created_at TIMESTAMP DEFAULT now(),
    FOREIGN KEY (list_id) REFERENCES list(id)
);

CREATE TABLE tag(
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE task_tag(
   task_id INT NOT NULL REFERENCES tasks(id) ON DELETE CASCADE,
   tag_id INT NOT NULL REFERENCES tag(id) ON DELETE CASCADE,
   PRIMARY KEY (task_id, tag_id)
);