use serde::ser::{Serialize, SerializeStruct, Serializer};
use std::cmp::Ordering;

#[derive(Eq)]
pub struct Occurrence {
    num: i32,
    count: i32,
}

impl Serialize for Occurrence {
    fn serialize<S>(&self, serializer: S) -> Result<S::Ok, S::Error>
    where
        S: Serializer,
    {
        // 2 is the number of fields in the struct.
        let mut state = serializer.serialize_struct("Occurrence", 3)?;
        state.serialize_field("num", &self.num)?;
        state.serialize_field("count", &self.count)?;
        state.end()
    }
}

impl Ord for Occurrence {
    fn cmp(&self, other: &Self) -> Ordering {
        self.num.cmp(&other.num)
    }
}

impl PartialOrd for Occurrence {
    fn partial_cmp(&self, other: &Self) -> Option<Ordering> {
        Some(self.cmp(other))
    }
}

impl PartialEq for Occurrence {
    fn eq(&self, other: &Self) -> bool {
        self.num == other.num
    }
}
